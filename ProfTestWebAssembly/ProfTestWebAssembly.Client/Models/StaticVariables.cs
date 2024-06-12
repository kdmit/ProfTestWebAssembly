
using static ProfTestWebAssembly.Client.Pages.Test;

namespace ProfTestWebAssembly.Client.Models
{
    public static class StaticVariables
    {
        
        public static string UserName { get; set; } = "Неизвестный";
        public static string Region = "";
        public static OrgType orgType;
        public static TypeAnswer changeType;


        public static Dictionary<TypeAnswer, int[]> UserScores { get; set; } = new Dictionary<TypeAnswer, int[]>()
        {
            {TypeAnswer.Human_Nature, new int[0]}, 
            {TypeAnswer.Human_Technique,new int[0] }, 
            {TypeAnswer.Human_Human, new int[0] },
            {TypeAnswer.Human_SignSystem,new int[0] }, 
            {TypeAnswer.Human_Art,new int[0]}
        };

        public static TypeAnswer getMaxTypeAnswer()
        {
            TypeAnswer maxKey = UserScores.MaxBy(d=>d.Value.Sum()).Key;
            return maxKey;
        }

        public static string getYourProfession() => getMaxTypeAnswer() switch
        {
                TypeAnswer.Human_Nature         => "Человек-природа",
                TypeAnswer.Human_Technique      => "Человек-техника",
                TypeAnswer.Human_Human          => "Человек-человек",
                TypeAnswer.Human_SignSystem     => "Человек-знаковая система",
                TypeAnswer.Human_Art            => "Человек - художественный образ"
        };

    }
}
