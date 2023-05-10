// function topla1(x,y){
//     return x+y;
// }
function topla6(x, y) {
    return x + y;
}
console.log(topla6(8, 3));
function topla4(x, y) {
    if (y) {
        return x + y;
    }
    return x;
}
console.log(topla4(13, 3));
function davetEt(ilkDavetli) {
    var digerleri = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        digerleri[_i - 1] = arguments[_i];
    }
    return ilkDavetli + " " + digerleri.join(" ");
}
console.log("Derin", "Salih", "Engin");
