using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Sort
{
 
    class Program 
    {

      
        static void Main(string[] args)
        {
            
            List<String> list = new List<String>();
            Int32 start, mid, end;
            start = 0;
            mid = 0;
            end = 0;
            String input="";
            char y = 'y';
            Console.WriteLine("Enter Number or Press 0 to Finish the Program");
            while (y !='n')
            {

                input = Console.ReadLine();
                if (input == "0")
                {
                    foreach (var e in list)
                    {
                        Console.WriteLine(e);
                    }
                    Console.WriteLine("Want to enter more elements? Press 'y' for yes or 'n' for no"); //Yes or No check
                    y = Convert.ToChar(Console.ReadLine());
                    if (y == 'n')
                    {
                        Console.WriteLine("Enter");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
             
                if (list.Count == 0)
                {
                    //first number and its space
                    list.Add(input);
                    list.Add(" ");
                    end = list.Count - 1;
                    mid = (start + end) / 2;
                    continue;
                }
                else if (list.Count == 2 && Convert.ToInt32(list[0]) < Convert.ToInt32(input)) //second number and the  balancing
                {
                    list.Insert(1, input);
                    list = Rebalance(list);
                    end=list.Count -1;
                    mid = (start+end) /2;
                    
                    continue;
                }
                else if (list.Count == 2 && Convert.ToInt32(list[0]) > Convert.ToInt32(input)) //second number and balancing if smaller
                {
                    list.Insert(0, input);
                    list = Rebalance(list);
                    end = list.Count - 1;
                    mid = (start + end) / 2;
                    
                    continue;
                }
               
                else
                {
               
                    while (start!=end) //binary search to find place of new number
                    {
                        if (list[mid] == " " && Convert.ToInt32(list[mid + 1]) < Convert.ToInt32(input))//binary search condition when mid = space
                        {
                            start = mid + 1;
                            mid = (start + end) / 2;
                            continue;
                        }
                        else if (list[mid] == " " && Convert.ToInt32(list[mid + 1]) > Convert.ToInt32(input))
                        {
                            end = mid - 1;
                            mid = (start + end) / 2;
                            continue;
                        }
                        if(list[mid] != " " && Convert.ToInt32(list[mid]) < Convert.ToInt32(input)) //binary search condition when mid = number
                        {
                            start = mid + 1;
                            mid = (start + end) / 2;
                            continue;

                        }
                        else if(list[mid] != " " && Convert.ToInt32(list[mid]) > Convert.ToInt32(input))
                        {
                            end = mid - 1;
                            mid = (start + end) / 2;
                            continue;
                        }
                     
                    }
                   
                }
                if (list[start] == " ")//space found, checking if space is empty or a number
                {
                    list.Insert(start, input);
                    list = Rebalance(list);
                }
                else
                {
                    if (Convert.ToInt32(list[start]) > Convert.ToInt32(input))
                    {
                        list.Insert(start, input);
                        list = Rebalance(list);
                    }
                    else
                    {
                        list.Insert(start + 1, input);
                        list = Rebalance(list);
                    }
                }
                start = 0;
                end = list.Count - 1;
                mid = (start + end) / 2;
              //every insert is followed by a call to balancing function
                

            }



            foreach(var e in list)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

        static List<String> Rebalance(List<String> List) //balancing function
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (i % 2 != 0 && List[i] != " ")
                {
                    List.Insert(i, " ");
                }
            }
           
            return List;
        }
    }
}
