using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    public ObservableCollection<Monkey> Monkeys { get; } = new ObservableCollection<Monkey>();
    MonkeyService MonkeyService { get; set; }
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey ViewModel - Title";
        this.MonkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GetMonkeys()
    {
        if(IsBusy) return;
        try
        {
            IsBusy = true;
            var monkeys = await MonkeyService.GetMonkeysAsync();

            if(Monkeys.Count > 0) { Monkeys.Clear(); }
            foreach (var item in monkeys)
            {
                Monkeys.Add(item);
            }
            //Monkeys.ToList().AddRange(monkeys);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);

            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
