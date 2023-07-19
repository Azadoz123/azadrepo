let meyveler = ["elma", "armut", "muz", "çilek"];

console.log(meyveler);
console.log(meyveler.includes("elma"));
console.log(meyveler.indexOf("elma"));
console.log(meyveler.push("kiraz"));
console.log(meyveler.pop());
meyveler.splice(meyveler.length - 1, 1)
console.log(meyveler);

let ogr1 = ["Yiğit", "Bilgi", 2010, [70, 60, 80]];
let ogr2 = ["Ada", "Bilgi", 2012, [80, 80, 90]];    
let ogr3 = ["Ahmet", "Turan", 2009, [60, 60, 70]];

let ogrenciler = [[
    "Yiğit", 
    "Bilgi", 
    2010, 
    [70, 60, 80]
], [
    "Ada", 
    "Bilgi", 
    2012, 
    [80, 80, 90]
], ogr3 ];

let yigit_yas = new Date().getFullYear() - ogrenciler[0][2];

let yigit_not = (ogrenciler[0][3][0] + ogrenciler[0][3][1] + ogrenciler[0][3][2]) / 3

console.log(yigit_yas);
console.log(yigit_not.toFixed(1));
