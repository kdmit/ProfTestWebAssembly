

namespace ProfTestWebAssembly.Client.Models
{
    public static class MyExtensionMethods
    {
        public static string RusToString(this EduForm value)
        {
            return value switch
            {
                EduForm.FullTime => "Очно",
                EduForm.CoRPD => "Заочно",
                EduForm.FullTime | EduForm.CoRPD => "Очно/Заочно",
                _ => "Unknown Enum"
            };     
        }

        public static string RusToString(this OrgType value)
        {
            return value switch
            {
                OrgType.ProfOrientation => "Профподготовка",
                OrgType.UpSkill => "Повышение квалификации",
                OrgType.College => "Среднее профессиональное",
                OrgType.University => "Высшее",

                _ => "Unknown Enum"
            };
        }

        public static string RusToString(this PaymentType value)
        {
            return value switch
            {
                PaymentType.Paid => "Платно",
                PaymentType.Free => "Бюджет",
                PaymentType.Free | PaymentType.Paid => "Бюджет/Платно",
                _ => "Unknown Enum"
            };
        }
    }

}
