interface Person {
    id: number;
    name: string;
    birth: Date;
    email: string;
    photo: string;
    password: string;
    salt: string;
}

interface LoginData
{
    indentify: string,
    password: string
}


export {Person, LoginData}