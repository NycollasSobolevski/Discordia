
interface GetUserPosts{
    jwt : string,
    page : number,
    quantity : number
}


interface PostCard {
    creatorIdJwt : string
    forumTitle : string
    title : string
    content : string
    attachment : boolean
    created : Date
}


export { GetUserPosts, PostCard }