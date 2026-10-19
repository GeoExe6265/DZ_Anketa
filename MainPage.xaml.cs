using System.Text;

namespace AnketaApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnShowResultClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(PhoneEntry.Text))
        {
            ResultFrame.IsVisible = false;
            await DisplayAlert("Ошибка", "Пожалуйста, заполните обязательные поля: Имя и Телефон!", "ОК");
            return;
        }

        var level = RbSenior.IsChecked ? "Senior" : RbMiddle.IsChecked ? "Middle" : "Junior";
        var summary = new StringBuilder()
            .AppendLine($"Имя: {NameEntry.Text.Trim()}")
            .AppendLine($"Телефон: {PhoneEntry.Text.Trim()}")
            .AppendLine($"Дата рождения: {BirthDatePicker.Date:dd.MM.yyyy}")
            .AppendLine($"Уровень: {level}")
            .AppendLine($"Язык: {TechPicker.SelectedItem ?? "Не выбран"}")
            .AppendLine($"Опыт: {Math.Round(ExpSlider.Value)} лет")
            .AppendLine($"Согласие: {(CbAgree.IsChecked ? "Да" : "Нет")}")
            .AppendLine($"Рассылка: {(CbSubscribe.IsChecked ? "Да" : "Нет")}")
            .AppendLine($"Удаленка: {(RemoteSwitch.IsToggled ? "Да" : "Нет")}")
            .AppendLine($"О себе: {(string.IsNullOrWhiteSpace(BioEditor.Text) ? "-" : BioEditor.Text.Trim())}");

        ResultText.Text = summary.ToString();
        ResultFrame.IsVisible = true;
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        NameEntry.Text = string.Empty;
        PhoneEntry.Text = string.Empty;
        BioEditor.Text = string.Empty;
        BirthDatePicker.Date = new DateTime(2000, 1, 1);
        ExpSlider.Value = 2;
        TechPicker.SelectedItem = null;
        RbJunior.IsChecked = true;
        CbAgree.IsChecked = false;
        CbSubscribe.IsChecked = true;
        RemoteSwitch.IsToggled = false;
        ResultText.Text = string.Empty;
        ResultFrame.IsVisible = false;
    }
}