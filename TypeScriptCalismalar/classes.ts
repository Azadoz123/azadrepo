class Ev{
    _odaSayisi:number;
    _pencereSayisi:number;
    _kat:number;
    constructor(odaSayisi:number, pencereSayisi: number, kat:number){
        this._odaSayisi = odaSayisi;
        this._pencereSayisi = pencereSayisi;
        this._kat = pencereSayisi;
    }
    yemekYe(){
        console.log(this._kat + " katlı evde " + "yemek Yiyildi");
    }
}

let ev = new Ev (3,4,5)
ev.yemekYe();

class Kisi{
    kaydet(){
        console.log("Kişi kaydedildi.")
    }
}

class Musteri extends Kisi{
    private _isim:string;

     get isim():string{
        return "Sayın : " + this._isim;
     }

     set isim(ad:string){
        this._isim = ad;
     }
    satisYap(){
        console.log("Satış yapıldı.")
    }
}

class Personel extends Kisi{
    maasOde(){
        console.log("Maaş Ödendi")
    }
}

let musteri = new Musteri()
musteri.isim = "Engin";
console.log(musteri.isim);
musteri.kaydet();
musteri.satisYap();

let personel = new Personel();
personel.kaydet();
personel.maasOde();