    interface Product{
        id:number;
        name:string;
        untiPrice:number;
    }

    function save(product:Product){
        console.log(product.name + " kaydedildi.")
    }

    save({id:1, name:"laptop", untiPrice:10})

    interface IPersonelService{
        save();
    }

    class CustonerService implements IPersonelService{
        save() {
            throw new Error("Method not implemented.");
        }

    }