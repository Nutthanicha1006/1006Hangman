using System;
using System.Collections.Generic; //เพื่อให้สามารถใช้ คำสั่ง List ได้
using System.Text; //เพื่อให้สามารถใช้ คำสั่ง StringBuilder ได้

enum Menu
{
    PlayGame = 1, // หน้าPlayGame = คำสั่ง 1
    Exit //นอกเหนือคำสั่ง 1 คือ Exit
}

namespace Hangman
{
    class Program 
    {
        static void Main(string[] args) //การทำงานหลัก
        {
            Welcome(); //เข้าสู่กระบวนการ Welcome
            SelectMenu(); //เข้าสู่กระบวนการ SelectMenu
        }

        static void Welcome() //กระบวนการ Welcome
        {
            Console.WriteLine("Welcome to Hangman Game"); //แสดงข้อความ ต้อนรับ
            Console.WriteLine("----------------------------------------"); //แสดงข้อความ - เพื่อความสวยงาม
            Console.WriteLine("1. Play game"); //แสดงข้อความ 1. Play game เข้าสู่หน้าเกม
            Console.WriteLine("2. Exit"); //แสดงข้อความ 2. Exit ออกจากเกม
        }

        static void SelectMenu() //กระบวนการ SelectMenu
        {
            Console.Write("Please Select Menu: "); //แสดงข้อความ ให้เลือกเมนู
            Menu menu = (Menu)(int.Parse(Console.ReadLine())); //รับคำสั่ง
            ShowScreen(menu); //เข้าสู่กระบวนการ ShowScreen
        }
        static void ShowScreen(Menu menu) //กระบวนการ ShowScreen
        {
            if (menu == Menu.PlayGame) //ถ้าหากคำสั่งตรงกับ Menu.PlayGame (คำสั่ง = 1)
            {
                HangManGame(); //เข้าสู่กระบวนการ HangManGame
            }
            else //ถ้าหากคำสั่งไม่ตรงกับ Menu.PlayGame (คำสั่ง = 1)
            {
                Environment.Exit(0); //ออกจากระบบ
            }
        }

        static void HangManGame() //กระบวนการ HangManGame
        {
            Random random = new Random((int)DateTime.Now.Ticks); //สร้างตัวแปร random คำศัพท์

            string[] WordsList = { "tennis", "football", "badminton" }; //กำหนดคำศัพท์ลงใน List
            string word = WordsList[random.Next(0, WordsList.Length)]; //random คำศัพท์

            Console.WriteLine("Play Game Hangman"); //แสดงข้อความ Play Game Hangman
            Console.WriteLine("----------------------------------------"); //แสดงข้อความ  - เพื่อความสวยงาม
            Console.WriteLine("Incorrect Score: 0"); //แสดงข้อความ Incorrect Score: 0 จำนวนครั้งที่ตอบผิด

            StringBuilder Guess = new StringBuilder(word.Length); //จำนวนตัวอักษรของคำศัพท์
            for (int i = 0; i < word.Length; i++) //ถ้าหาก i < ตัวอักษรของคำศัพท์
            {
                Guess.Append('_'); //ให้นำ _ แทน ตัวอักษร
            }

            int Countunderscore = word.Length; //จำนวน _
            List<char> CorrectLetterAlphabet = new List<char>(); //สร้างตัวแปรList สำหรับตัวอักษรที่ถูกต้อง
            List<char> IncorrectLetterAlphabet = new List<char>(); //สร้างตัวแปรList สำหรับตัวอักษรที่ไม่ถูกต้อง

            int lives = 6; //กำหนดตัวแปรให้เป็นผลรวมจำนวนครั้งที่ตอบผิดได้
            int Correct = 0; //กำหนดตัวแปรให้เป็นจำนวนครั้งที่ตอบถูก
            int Incorrect = 0; //กำหนดตัวแปรให้เป็นจำนวนครั้งที่ตอบผิด
            bool won = false; //กำหนดเงื่อนไข won = ผิดเงื่อนไข
            char inputLetterAlphabet; //กำหนดตัวแปรรับค่าตัวอักษร

            CountUnderscore(Countunderscore); //เข้าสู่กระบวนการ CountUnderscore

            while (!won && lives != 0) //ถ้าหากยังไม่ชนะ และ ผลรวมจำนวนครั้งที่ตอบผิดไม่เท่ากับ 0
            {
                Console.WriteLine(""); //อันนี้ใส่เพราะข้อความต่อไปจะได้ไปอยู่บรรทัดใหม่
                Console.Write("Input letter alphabet: "); //แสดงข้อความ ให้ใส่ตัวอักษร
                inputLetterAlphabet = char.Parse(Console.ReadLine()); //เก็บข้อมูลที่รับมาไว้ในตัวแปร inputLetterAlphabet

                if (word.Contains(inputLetterAlphabet)) //ถ้าหากตัวอักษรนั้นถูกต้อง
                {
                    CorrectLetterAlphabet.Add(inputLetterAlphabet); //นำข้อมูลที่ตอบถูกทั้งหมดใส่ใน CorrectLetterAlphabet

                    Console.Clear(); //เคลียร์ข้อความอันเก่า
                    Console.WriteLine("Play Game Hangman"); //แสดงข้อความ Play Game Hangman
                    Console.WriteLine("----------------------------------------"); //แสดงข้อความ  - เพื่อความสวยงาม
                    Console.WriteLine("Incorrect Score: {0}", Incorrect); //แสดงจำนวนครั้งที่ตอบผิด

                    for (int i = 0; i < word.Length; i++)  //ถ้าหาก i < จำนวนอักษรของคำศัพท์
                    {
                        if (word[i] == inputLetterAlphabet) //ถ้าอักษรของคำศัพท์ = อักษรการเดา
                        {
                            Guess[i] = word[i]; //อักษรที่เดาถูกต้อง = อักษรของคำศัพท์
                            Correct++; //บวกจำนวนครั้งที่ตอบถูก
                        }
                    }
                    if (Correct == word.Length) //จำนวนครั้งที่ตอบถูก = จำนวนอักษรของคำศัพท์
                    {
                        Console.WriteLine("{0}", word); //แสดงเฉลยคำศัพท์ที่ random ออกมา
                        win(); //เข้าสู่กระบวนการ win
                    }
                }
                else //ถ้าหากตัวอักษรนั้นไม่ถูกต้อง
                {
                    IncorrectLetterAlphabet.Add(inputLetterAlphabet); //นำข้อมูลที่ตอบผิดทั้งหมดใส่ใน IncorrectLetterAlphabet

                    Console.Clear(); //เคลียร์ข้อความอันเก่า
                    Console.WriteLine("Play Game Hangman"); //แสดงข้อความ Play Game Hangman
                    Console.WriteLine("----------------------------------------"); //แสดงข้อความ  - เพื่อความสวยงาม

                    Incorrect++; //บวกจำนวนครั้งที่ตอบผิด

                    Console.WriteLine("Incorrect Score: {0}", Incorrect); //แสดงจำนวนครั้งที่ตอบผิด
                    lives--; //จำนวนครั้งที่ตอบผิดจะลดลงทีละ 1

                    if (lives == 0) //ถ้าหาก จำนวนครั้งที่ตอบผิด = 0
                    {
                        Console.WriteLine("{0}", word); //แสดงเฉลยคำคำศัพท์ที่ random ออกมา
                        lose(); //เข้าสู่กระบวนการ lose
                    }
                }
                Console.WriteLine(Guess.ToString()); //แสดงผลล่าสุด
            }

        }

        static void CountUnderscore(int Countunderscore) //กระบวนการ CountUnderscore
        {
            for (int i = 0; i < Countunderscore; i++) ////ถ้าหาก i < จำนวน _ ที่แทนตัวอักษรของคำศัพท์
            {
                Console.Write("_"); //แสดง _
            }
        }

        static void win() //กระบวนการ win
        {

            Console.WriteLine("Input letter alphabet: ");  //แสดงข้อความ Input letter alphabet: 
            Console.WriteLine("You win!!"); //แสดงข้อความ You win!!
            Environment.Exit(0); //ออกจากระบบ

        }

        static void lose() //กระบวนการ lose
        {

            Console.WriteLine("Input letter alphabet: "); //แสดงข้อความ Input letter alphabet: 
            Console.WriteLine("Game Over"); //แสดงข้อความ
            Environment.Exit(0); //ออกจากระบบ

        }   
    }
}
