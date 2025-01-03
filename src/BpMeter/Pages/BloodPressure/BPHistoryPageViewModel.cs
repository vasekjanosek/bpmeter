﻿using BpMeter.Application.Abstractions;
using BpMeter.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BpMeter.UI.Pages.BloodPressure;

public class BPHistoryPageViewModel : ViewModelBase
{
    private readonly IBpReadingService _bpReadingService;

    private bool _isRefreshRunning;

    public ObservableCollection<BPRecordViewModel> History { get; } = new ObservableCollection<BPRecordViewModel>();

    public ICommand RefreshCommand { get; }

    public ICommand ShowDetailsCommand { get; }

    public ICommand HideDetailsCommand { get; }

    public bool IsRefreshRunning
    {
        set { SetProperty(ref _isRefreshRunning, value); }
        get { return _isRefreshRunning; }
    }

    public BPHistoryPageViewModel(IBpReadingService bpReadingService)
    {
        _bpReadingService = bpReadingService;

        RefreshCommand = new Command(
            execute: async () =>
            {
                await GetMeasuringHistoryAsync();
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return !IsRefreshRunning;
            });

        ShowDetailsCommand = new Command(
            execute: (object param) =>
            {
                ShowDetails((BPRecordViewModel)param, true);
            },
            canExecute: (object param) =>
            {
                return true;
            });

        HideDetailsCommand = new Command(
            execute: (object param) =>
            {
                ShowDetails((BPRecordViewModel)param, false);
            },
            canExecute: (object param) =>
            {
                return true;
            });

        Task.Run(GetMeasuringHistoryAsync);
    }

    protected override void RefreshCanExecutes()
    {
        ((Command)RefreshCommand).ChangeCanExecute();
    }

    private async Task GetMeasuringHistoryAsync()
    {
        IsRefreshRunning = true;
        try
        {

            var history = await _bpReadingService.GetAllReadingsAsync();

            History.Clear();

            /*var groupedHistory = history.GroupBy(x => DateOnly.FromDateTime(x.DateTime)).OrderBy(group => group.Key);
            foreach (var group in groupedHistory)
            {
                History.Add(new RecordGroup(group.Key.ToString(), group.ToList()));
            }*/

            foreach (var record in history)
            {
                History.Add(new BPRecordViewModel(record));
            }
        }
        catch (Exception ex)
        {
        }

        IsRefreshRunning = false;
    }

    private void ShowDetails(BPRecordViewModel param, bool show)
    {
        param.ShowDetails = show;
    }
}
