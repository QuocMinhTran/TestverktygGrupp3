﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVerktygWPF.Model;

namespace TestVerktygWPF.ViewModel
{
    public class TestHandler
    {
        private Test xTest;
        private List<Questions> xQuestions;
        private List<Answer> xAnswer;
        private UserTest xUserTest;

        public TestHandler()
        {
            xAnswer = new List<Answer>();
            xQuestions = new List<Questions>();
            xTest = new Test();
            xUserTest = new UserTest();
        }

        public bool CreateTest(Test xTest, List<Questions> xQuestions, List<Answer> xAnswer, int teacherID)
        {
            Repository xRepo = new Repository();
            xRepo.SaveTest(xTest);
            int temp;
            int iTestID = xRepo.GetTest(xTest.Name).ID; 
            foreach (var item in xQuestions)
            {
                int tempo = item.ID;
                item.TestFk = iTestID;
                temp =  xRepo.SaveQuestion(item);
                foreach(var ItemAnswer in xAnswer)
                {
                    if(ItemAnswer.QuestionFk == tempo)
                    {
                        ItemAnswer.QuestionFk = temp;
                        xRepo.SaveAnwnser(ItemAnswer);
                    }
                }
            }
            xUserTest.TestFk = iTestID;
            xUserTest.UserFk = teacherID;
            xRepo.SaveUserTest(xUserTest);
            return true;
        }

    }
}
