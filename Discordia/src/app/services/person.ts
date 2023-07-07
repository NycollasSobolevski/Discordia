
interface LoginData
{
    indentify: string,
    password: string
}

interface Jwt 
{
    value?: string,
}

interface UserData
{
    userName : string,
    email : string,
    photo : string,
    birthday : string
}



export { LoginData, Jwt, UserData }