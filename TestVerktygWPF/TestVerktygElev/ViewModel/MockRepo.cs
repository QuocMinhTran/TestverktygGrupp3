using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVerktygWPF.Model;

namespace TestVerktygElev.ViewModel
{
    public class MockRepo
    {
       public MockRepo()
        {
            Teacher teacher = new Teacher();
            teacher.FirstName = "fuck";
            teacher.LasttName = "fuckerson";

            Student student = new Student();

            Test test = new Test();
            test.Name = "honk honk motherfucker";
            test.StartDate = DateTime.Today;
            test.EndDate = DateTime.Today.AddDays(1);
            test.TeacherRefFK = teacher.TeacherID;


            QuestionType type1 = new QuestionType();
            type1.Option = "Envalsfråga";

            QuestionType type2 = new QuestionType();
            type2.Option = "Flervalsfråga";

            Questions question = new Questions();
            question.QuestionsLabel = "What the fuck did you just fucking say about me, you little bitch? I’ll have you know I graduated top of my class in the Navy Seals, and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You’re fucking dead, kiddo.";
            question.QuestTypeRefFK = type1.QuestionTypeID;

            Option option = new Option();
            option.SelectivOption = "Gorilla Warfare";
            option.RightAnswer = true;

            Option option2 = new Option();
            option2.SelectivOption = "united nations space command";
            option2.RightAnswer = false;

            Questions question2 = new Questions();
            question2.QuestionsLabel = "what is shitposting";
            question2.QuestTypeRefFK = type2.QuestionTypeID;

            Option option3 = new Option();
            option3.SelectivOption = "The failure to make a constructive post ";
            option3.RightAnswer = true;

            Option option4 = new Option();
            option4.SelectivOption = "The inability to add useful information to a forum";
            option4.RightAnswer = true;

            Option option5 = new Option();
            option5.SelectivOption = "Worthless overly offensive generally racists posts written in a manner which aggravates others";
            option5.RightAnswer = true;

            TestQuestion tstqst = new TestQuestion();
            tstqst.TestRefFk = test.TestID;
            tstqst.QuestionRefFk = question.QuestionID;
            TestQuestion tstqst2 = new TestQuestion();
            tstqst2.TestRefFk = test.TestID;
            tstqst2.QuestionRefFk = question2.QuestionID;

            List<Questions> questionList = new List<Questions>();
            List<Option> optionsList = new List<Option>();
            questionList.Add(question);
            questionList.Add(question2);
            questionList.Add(question2);
            questionList.Add(question2);
        }
    }
}
