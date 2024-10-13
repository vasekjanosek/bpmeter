using BpMeter.Application;
using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Mvvm;
using System.Windows.Input;

namespace BpMeter.UI.Pages.Settings;

public class PersonalInformationPageViewModel : ViewModelBase
{
    private readonly IPersonalInformationService _personalInformationService;
    private readonly IBwReadingService _bwReadingService;

    private string _firstName;
    private string _middleName;
    private string _lastName;
    private DateOnly _birthDate;
    private double _height;
    private double _weight;
    private double _bmi;

    public string FirstName
    {
        set { SetProperty(ref _firstName, value); }
        get { return _firstName; }
    }

    public string MiddleName
    {
        set { SetProperty(ref _middleName, value); }
        get { return _middleName; }
    }

    public string LastName
    {
        set { SetProperty(ref _lastName, value); }
        get { return _lastName; }
    }

    public DateOnly BirthDate
    {
        set { SetProperty(ref _birthDate, value); }
        get { return _birthDate; }
    }

    public int Age
    {
        get
        {
            var age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-age))) age--;
            return age;
        }
    }

    public double Height
    {
        set { SetProperty(ref _height, value); }
        get { return _height; }
    }

    public double Weight
    {
        set { SetProperty(ref _weight, value); }
        get { return _weight; }
    }

    public double BMI
    {
        get
        {
            return Weight / Math.Pow(Height, 2);
        }
    }

    public ICommand ChangePageCommand { get; set; }

    public ICommand ExitCommand { get; set; }

    public ICommand ApplyChangesCommand { get; set; }

    public PersonalInformationPageViewModel(IPersonalInformationService personalInformationService, IBwReadingService bwReadingService)
    {
        _personalInformationService = personalInformationService;
        _bwReadingService = bwReadingService;

        ChangePageCommand = new Command(
            execute: async (page) =>
            {
                await GoToPage((string)page);
            });

        ExitCommand = new Command(
            execute: () =>
            {
                Microsoft.Maui.Controls.Application.Current?.Quit();
            });

        ApplyChangesCommand = new Command(
            execute: async () =>
            {
                await ApplyChanges();
            });
    }

    public async Task GoToPage(string page)
    {
        await Shell.Current.GoToAsync(page);
    }

    public void ClearValues()
    {
        FirstName = string.Empty;
        MiddleName = string.Empty;
        LastName = string.Empty;
        BirthDate = DateOnly.MinValue;
        Height = 0;
        Weight = 0;
    }

    public async Task Initialize()
    {
        if (await _personalInformationService.IsPersonalInformationFilled())
        {
            var personalInfo = await _personalInformationService.GetPersonalInformation();
            if (personalInfo != null)
            {
                var bwReading = await _bwReadingService.GetLastReadingAsync();
                FirstName = personalInfo.FistName;
                MiddleName = personalInfo.MiddleName;
                LastName = personalInfo.LastName;
                BirthDate = personalInfo.BirthDate;
                Height = personalInfo.HeightInCm;
                Weight = bwReading.WeightInKg;
            }
        }
    }

    public async Task ApplyChanges()
    {
        await _personalInformationService.AddPersonalInformation(FirstName, MiddleName, LastName, BirthDate, GetHeight());
    }

    private int GetHeight()
    {
        return (int)Height;
    }
}
