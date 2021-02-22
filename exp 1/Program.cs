//Read a Text File
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace exp1
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
                Console.WriteLine("1. Распроведение:  \n 2. Перевыслать:  \n 3. Принять:  \n 4. Данные магазина: ");

            if (Console.ReadLine() == "4")
            {

                Console.Write("Введите FSRAR: ");
                string FSRAR = Console.ReadLine();
                Console.Write("Введите IP: ");
                string IP = Console.ReadLine();

                string[] lineArrayMain = new string[25];
                string[] lineArraySend = new string[3];

                string lineSend;
                string line;

                void readAllText()
                {
                    using StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\QueryClients_v2.xml");

                    line = sr.ReadLine();
                    for (int i = 0; line != null; i++) // запись в массив
                    {
                        lineArrayMain[i] = line;
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                try
                {
                    // -------------------------- Читаем QC ----------------------------------
                    readAllText();
                    // ------------------------------ Вписываем QC -----------------------------
                    using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\QueryClients_v2.xml"))
                    {
                        for (int i = 0; lineArrayMain[i] != null; i++) // цикл пока не найдем пустую строчку
                        {
                            if (lineArrayMain[i] == "<qp:Value></qp:Value>") // Ищем данную строчку и вписываем свой FSRAR
                            {
                                lineArrayMain[i] = "<qp:Value>" + FSRAR + "</qp:Value>";
                                sw.WriteLine(lineArrayMain[i]);
                                Console.WriteLine(lineArrayMain[i]);
                            }

                            else if (lineArrayMain[i] == "<ns:FSRAR_ID></ns:FSRAR_ID>") // Такая же вторая строчка
                            {
                                lineArrayMain[i] = "<ns:FSRAR_ID>" + FSRAR + "</ns:FSRAR_ID>";
                                sw.WriteLine(lineArrayMain[i]);
                                Console.WriteLine(lineArrayMain[i]);
                            }
                            else
                            {
                                sw.WriteLine(lineArrayMain[i]);
                                Console.WriteLine(lineArrayMain[i]);
                            }
                        }
                        Console.WriteLine("----------------------------------------------------------");
                        sw.Close();
                    }



                    //----------------------------Читаем Send.cmd -------------------------
                    using StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\send.cmd");

                    lineSend = sr.ReadLine();
                    for (int i = 0; lineSend != null; i++) // запись в массив
                    {
                        lineArraySend[i] = lineSend;
                        lineSend = sr.ReadLine();
                    }
                    sr.Close();
                    //----------------------------Вписываем Send.cmd---------------------------------
                    using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\send.cmd"))
                    {
                        for (int i = 0; lineArraySend[i] != null; i++) // цикл, пока не найдем пустую строчку
                        {
                            if (lineArraySend[i] == ("curl -F \"xml_file=@C:\\Users\\User\\Desktop\\QueryClients_v2\\QueryClients_v2.xml\" http://:8082/opt/in/QueryClients_v2"))
                            {
                                lineArraySend[i] = ("curl -F \"xml_file=@C:\\Users\\User\\Desktop\\QueryClients_v2\\QueryClients_v2.xml\" http://" + IP + ":8082/opt/in/QueryClients_v2");
                                sw.WriteLine(lineArraySend[i]);
                                Console.WriteLine(lineArraySend[i]);
                            }
                            else
                            {
                                sw.WriteLine(lineArraySend[i]);
                                Console.WriteLine(lineArraySend[i]);
                            }
                        }

                        sw.Close();
                    }





                    Process.Start("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\send.cmd");
                    
                   








                    // ------------------------- Возвращаем в чистое значение QC ---------------------------

                    readAllText(); // Заного записываем весь текст в массив, чтобы вернуть всё в нулевое значение
                    using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\QueryClients_v2.xml"))
                    {
                        for (int i = 0; lineArrayMain[i] != null; i++) // цикл, пока не найдем пустую строчку
                        {
                            if (lineArrayMain[i] == ("<qp:Value>" + FSRAR + "</qp:Value>"))
                            {
                                lineArrayMain[i] = "<qp:Value></qp:Value>";
                                sw.WriteLine(lineArrayMain[i]);
                            }
                            else if (lineArrayMain[i] == ("<ns:FSRAR_ID>" + FSRAR + "</ns:FSRAR_ID>"))
                            {
                                lineArrayMain[i] = "<ns:FSRAR_ID></ns:FSRAR_ID>";
                                sw.WriteLine(lineArrayMain[i]);
                            }
                            else
                            {
                                sw.WriteLine(lineArrayMain[i]);
                            }
                        }

                        sw.Close();
                    }
                    // ------------------------- Возвращаем в чистое значение send.cmd ---------------------------
                    using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\send.cmd"))
                    {
                        for (int i = 0; lineArraySend[i] != null; i++) // цикл, пока не найдем пустую строчку
                        {
                            if (lineArraySend[i] == ("curl -F \"xml_file=@C:\\Users\\User\\Desktop\\QueryClients_v2\\QueryClients_v2.xml\" http://" + IP + ":8082/opt/in/QueryClients_v2"))
                            {
                                lineArraySend[i] = ("curl -F \"xml_file=@C:\\Users\\User\\Desktop\\QueryClients_v2\\QueryClients_v2.xml\" http://:8082/opt/in/QueryClients_v2");
                                sw.WriteLine(lineArraySend[i]);
                            }
                            else
                            {
                                sw.WriteLine(lineArraySend[i]);
                            }
                        }

                        sw.Close();
                        Console.WriteLine("-------------------------Конец программы-------------------------------");


                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            //--------------------------Распроведение---------------------------
            if (Console.ReadLine() == "1")
            {
                Console.Write("Введите FSRAR: ");
                string FSRAR = Console.ReadLine();
                Console.Write("Введите IP: ");
                string IP = Console.ReadLine();

                string[] lineArrayMain = new string[25];
                string[] lineArraySend = new string[3];

                string line;
               //string lineSend;

                void readAllText() // Test
                {
                    using StreamReader sr = new StreamReader("C:\\Users\\User\\Desktop\\RequestRepealWB\\Test\\RequestRepealWB.xml");

                    line = sr.ReadLine();
                    for (int i = 0; line != null; i++) // запись в массив
                    {
                        lineArrayMain[i] = line;
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }

                try
                {
                    readAllText();

                    using (StreamWriter sw = new StreamWriter("C:\\Users\\User\\Desktop\\QueryClients_v2\\Test\\QueryClients_v2.xml"))
                    {
                        for (int i = 0; lineArrayMain[i] != null; i++) // цикл пока не найдем пустую строчку
                        {
                            if (lineArrayMain[i] == "<qp:Value></qp:Value>") // Ищем данную строчку и вписываем свой FSRAR
                            {
                                lineArrayMain[i] = "<qp:Value>" + FSRAR + "</qp:Value>";
                                sw.WriteLine(lineArrayMain[i]);
                                Console.WriteLine(lineArrayMain[i]);
                            }

                            else if (lineArrayMain[i] == "<qp:ClientId></qp:ClientId>") // Такая же вторая строчка
                            {
                                lineArrayMain[i] = "<qp:ClientId>" + FSRAR + "</qp:ClientId>";
                                sw.WriteLine(lineArrayMain[i]);
                                Console.WriteLine(lineArrayMain[i]);
                            }
                            else if (lineArrayMain[i] == "<qp:RequestDate></qp:RequestDate>")
                            {
                                Console.WriteLine("Введите год, месяц, день. Например: 2020-10-02");
                                Console.ReadLine();
                            }
                            else
                            {
                                sw.WriteLine(lineArrayMain[i]);
                                Console.WriteLine(lineArrayMain[i]);
                            }
                        }
                        Console.WriteLine("----------------------------------------------------------");
                        sw.Close();

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }

                // конец
            }
        }
    }
}