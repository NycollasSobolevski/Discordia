interface Forum {
    Id? : number
    CreatorId? : number 
    Title? : string 
    Created? : Date
    Description? : string 
    Creator? : string
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

interface Post {
    creatorIdJwt? : string
    forumTitle : string
    title : string
    content : string
    attachment : boolean
    created : Date
}

interface PostCard {
    creatorIdJwt : string
    forumTitle : string
    title : string
    content : string
    attachment : boolean
    created : Date
}

export { Forum, Person, Post, PostCard }