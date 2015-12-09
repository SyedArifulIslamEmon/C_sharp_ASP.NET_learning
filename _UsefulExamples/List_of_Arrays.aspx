// create a list of arrays.
var newArray = new List<string[]>();

newArray.Add(new string[] { "One", "Two", "Three" });      // an array with strings
newArray.Add(new string[] { "Four", "Five", "Six" });       // an array with strings

foreach(string[] item in newArray)
{
  // write 1st, 2nd, and 3rd items in the array, with Array[index]
  Response.Write(item[0] + " " + item[1] + " " + item[2] + "<br />");
}
