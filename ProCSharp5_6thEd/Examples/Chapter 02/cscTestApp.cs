//simple C# app to toy with csc.exe
using System;
/*continuing example
using System.Windows.Forms;*/

class TestApp
{
  static void Main()
  {
    Console.WriteLine("Testing or summat");
/*continuing example
    MessageBox.Show("Moooore testing!");*/
    HelloMessage h = new HelloMessage();
    h.Speak();
  }
}