// function topla1(x,y){
//     return x+y;
// }

function topla6(x:number, y:number):number{
    return x+y;
}

console.log(topla6(8,3))

function topla4(x:number, y?:number){
    if(y){
        return x+y;
    }

    return x;
}

console.log(topla4(13,3))

function davetEt(ilkDavetli:string, ...digerleri:string[]):string{
    return ilkDavetli + " " + digerleri.join(" ")
}

console.log("Derin", "Salih", "Engin")