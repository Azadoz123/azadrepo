for(let i = 0; i < 10; i++ ){
console.log(i)
}
let toplam = 0;

let sayilar = [1, 2, 3, 4, 5, 6];

for(let index in sayilar){
    toplam += sayilar[index];
    
}

for(let sayi of sayilar){
    toplam += sayi;
}

console.log(toplam);

let user = {
    "name" : "Sadık Turan",
    "username" : "sadikturan",
    "password" : "123456",
    "email" : "info@sadikturan.com"
};

for (let key in user){
    console.log(key)
    console.log(user[key])
    
}