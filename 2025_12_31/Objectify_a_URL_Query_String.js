//https://www.codewars.com/kata/5286d92ec6b5a9045c000087
/*
In this kata, we want to convert a URL query string into a nested object. The query string will contain parameters that may or may not have embedded dots ('.'), and these dots will be used to break up the properties into the nested object.

You will receive a string input that looks something like this:

user.name.firstname=Bob&user.name.lastname=Smith&user.favoritecolor=Light%20Blue
Your method should return an object hash-map that looks like this:

{
  'user': {
    'name': {
      'firstname': 'Bob',
      'lastname': 'Smith'
    },
    'favoritecolor': 'Light Blue'
  }
}
You can expect valid input. You won't see input like:
// This will NOT happen
foo=1&foo.bar=2
All properties and values will be strings — and the values should be left as strings to pass the tests.
Make sure you decode the URI components correctly
*/
function convertQueryToMap(query) {
  let obj = query.split('&');
  let rst = {};
  
  const getHash = (key, value, map) => {
    if(key.indexOf('.') < 0) {
      map[key] = decodeURIComponent(value);
      return;
    }
    let k = key.split('.')[0];
    if(map[k] == undefined) map[k] = {};
    getHash(key.slice(key.indexOf('.') + 1), value, map[k])
  }
  for(let i = 0; i < obj.length; i++) {
    let map = obj[i].split('=');
    if(map[0] == '') continue;
    getHash(map[0], map[1], rst);
  }
  return rst;
}