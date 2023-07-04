interface Forum {
    Id? : number
    CreatorId? : number 
    Title? : string 
    Created? : Date
    Description? : string 
}

interface Person {
    id: number;
    name: string;
    birth: Date;
    email: string;
    photo: string;
    password: string;
    salt: string;
}


export { Forum, Person }