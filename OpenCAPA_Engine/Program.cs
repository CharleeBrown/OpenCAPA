// See https://aka.ms/new-console-template for more information
using OpenCAPA_Engine;

Console.WriteLine("Hello, World!");
//CAPA aps = new CAPA("Test", "One");
//Console.WriteLine(Convert.ToString(aps.CAPA_ID));
DataLayer data = new DataLayer();

data.CreateCapaItem("Testing", "This is a test to see if the comments work?");