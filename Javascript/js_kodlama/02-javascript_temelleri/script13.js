function yaz(kelime, adet){
    for( let i = 0; i< adet; i++)
         console.log(kelime);
}

//yaz("Azad", 3)

function alanCerveHesapla(kisa, uzun){
    let alan = kisa * uzun;
    let cevre = (kisa + uzun) * 2;
    
    return `alan: ${alan} çevre: ${cevre}`;
}

let sonuc = alanCerveHesapla(7, 10);

// console.log(sonuc);

function yaziTuraAt(){
    let random = Math.random();
    if(random < 0.5){
        console.log("yazi " );
    }else{
        console.log("tura ");
    }

    console.log( random);
}

//yaziTuraAt();

function yazdir(sayi){
    let dizi = [];
    for(let i= 2; i<sayi; i++)
        if(sayi % i == 0){
            dizi.push(i);
        }      
    console.log(dizi);
}

yazdir(10);

function toplam(){
    let sonuc = 0;

    for(let i=0; i < arguments.length; i++){
        sonuc += arguments[i];
       
    }
    console.log(arguments);
    return sonuc;
    
}

console.log(toplam(2));
console.log(toplam(2, 5));
console.log(toplam(2, 6, 8));

var isim = "Ahmet";

function yazdir(){
    console.log(isim);
}