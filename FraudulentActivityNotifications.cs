//This was my first C# attempt to solve the challenge. It works for the first 3 test cases but fails due to timing out.
//I believe this is due to creating the list for sorting to find the median.

 static int activityNotifications(int[] expenditure, int d)
        {
     
            var notices = 0;
            var h = d / 2;

            List<int> list = new List<int>(expenditure.Skip(0).Take(d));


            for (var i = d; i < expenditure.Length - 1; i++)
            {
                List<int> values = list;
                values.Sort();

                var value = 0;

                if (d % 2 == 0)
                {
                    value = (values[h - 1] + values[h]) / 2;
                }
                else
                {
                    value = values[h];
                }

                if (value * 2 >= expenditure[i])
                {
                    notices++;
                    list.Take(0);
                    list.Add(expenditure[d]);
                }

            }

            Console.WriteLine(notices);
            Console.ReadKey();
            return notices;
        }

		



// This solution passes all test cases. 


 static int activityNotifications(int[] expenditure, int d)
        {
            int notices = 0;
            Queue<int> queue = new Queue<int>();
            int[] values = new int[201];
            for (var i = 0; i < expenditure.Length; i++)
            {
                if (i >= d)
                {
                    double median = 0;
                    var half = d / 2;
                    int val;
					
					//this for loop and the following if statement are a little unclear to me but they work
                    for (val = 0; values[val] < half; val++)
                    {
                        half -= values[val];
                    }
                    var med1 = val;
                    var med2 = val;
					
					
                    if (values[val] == half)
                    {
                        val++;
                        while (values[val] == 0)
                        {
                            val++;
                        }
                        med2 = val;
                    }
					
					
					
                    if (d % 2 == 0)
                    {
                        median = (double)(med1 + med2) / 2;
                    }
                    else
                    {
                        median = med2;
                    }
                    if (expenditure[i] >= median * 2)
                    {
                        notices++;
                    }
                    values[queue.Dequeue()]--;
                }

                values[expenditure[i]]++;
                queue.Enqueue(expenditure[i]);

            }

            Console.WriteLine(notices);
            Console.ReadKey();
            return notices;
        }
		
		
		
