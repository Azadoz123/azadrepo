abstract class KrediBase{
    constructor(){

    }
    kaydet():void{
        console.log("Kaydedildi.");
    }

    abstract hesapla():void;
}

class TuketiciKredi extends KrediBase{
    constructor(){
        super();
    }
    hesapla(): void {
        console.log("Tüketici kredisine göre hesap yapıldı");
    }

}

class KonutKredi extends KrediBase{
    constructor(){
        super();
    }
    hesapla(): void {
        console.log("Konut kredisine göre hesap yapıldı");
    }

}

let tuketiciKredi = new TuketiciKredi();
tuketiciKredi.hesapla();
tuketiciKredi.kaydet();

let konutKredi = new KonutKredi();
konutKredi.hesapla();
konutKredi.kaydet();

let kredi : KrediBase

kredi = new KonutKredi();

kredi = new TuketiciKredi();