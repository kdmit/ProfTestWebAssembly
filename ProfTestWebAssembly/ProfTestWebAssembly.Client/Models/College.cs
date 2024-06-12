
using System.ComponentModel;
using static ProfTestWebAssembly.Client.Pages.Test;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace ProfTestWebAssembly.Client.Models
{
    public class College
    {
        public static List<College> OrganizationList { get; set; } = new List<College>();
        public string Name { get; set; }
        public List<Faculty> ListOfFaculty = new List<Faculty>();
        public string City { get; set; }
        public string URL { get; set; }
        public OrgType orgType { get; set; }


        public static void LoadExcel(byte[] byteArray)
        {
            
            MemoryStream ms = new MemoryStream();
            ms.Write(byteArray, 0, byteArray.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ISheet sheet;
            XSSFWorkbook xsswb = new XSSFWorkbook(ms);
            sheet = xsswb.GetSheetAt(0);


            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);

                string s = row.GetCell(0).ToString();

                if (s == null || s == "") continue;

                College c = new College() { Name = s, City = row.GetCell(2).ToString(), URL = row.GetCell(3).ToString() };

                Console.WriteLine();
                
                c.orgType = row.GetCell(1).ToString() switch
                {
                    "Высшее" => OrgType.University,
                    "Среднее профессиональное" => OrgType.College,
                    "Профподготовка" => OrgType.ProfOrientation,
                    "Повышение квалификации" => OrgType.UpSkill
                };

                s = row.GetCell(4).ToString();

                for(int k = 1;  s != null && s != ""; k++)
                {
                    Faculty faculty = new Faculty() {Name = s};

                    faculty.EForm = row.GetCell(5).ToString() switch
                    {
                        "очно" => EduForm.FullTime,
                        "заочно" => EduForm.CoRPD,
                        "очно/заочно" => EduForm.FullTime | EduForm.CoRPD,
                    };

                    faculty.Payment = row.GetCell(6).ToString() switch
                    {
                        "платно" => PaymentType.Paid,
                        "бюджет" => PaymentType.Free,
                        "бюджет/платно" => PaymentType.Paid|PaymentType.Free,
                    };

                    faculty.typeAnswer = row.GetCell(7).ToString() switch
                    {
                        "Человек-природа" => TypeAnswer.Human_Nature,
                        "Человек-техника" => TypeAnswer.Human_Technique,
                        "Человек-человек" => TypeAnswer.Human_Human,
                        "Человек-знаковая система" => TypeAnswer.Human_SignSystem,
                        "Человек - художественный образ" => TypeAnswer.Human_Art,
                    };

                    c.ListOfFaculty.Add(faculty);

                    row = sheet.GetRow(i+k);

                    s = row.GetCell(4).ToString();

                }

                College.OrganizationList.Add(c);
            }


        }
    }

    public class Faculty
    {
        public string Name { get; set; }
        public PaymentType Payment { get; set; }
        public EduForm EForm {  get; set; }
        public TypeAnswer typeAnswer { get; set; }

    }

    [Flags]
    public enum PaymentType
    {
        Free = 1,
        Paid = 2    
    }

    [Flags]
    public enum EduForm
    {
        FullTime = 1,
        CoRPD = 2
    }

    public enum OrgType
    {
        [Description("Высшее образование")]
        University,
        [Description("Среднее профессиональное образование")]
        College,
        [Description("Профессиональная подготовка")]
        ProfOrientation,
        [Description("Повышение квалификации")]
        UpSkill
    }

}
