export class Model {
    user: any;
    items: TodoItems [];

    constructor(){
        this.user = 'Azad';
        this.items = [
         new TodoItems("Spor", true),
         new TodoItems("Kahvaltı", false),
         new TodoItems("Kitap Okumak", false),
         new TodoItems("Sinema", false),
        ];
    }
}

export class TodoItems{
    description;
    action;

    constructor(description: string, action: boolean){
        this.description = description;
        this.action = action;
    }
}
