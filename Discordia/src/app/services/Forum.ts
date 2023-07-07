import { Post, PostCard } from "./Model"
import { Jwt } from "./person"

interface ForumToBack{
    CreatorIdJwt : string
    Title : string
    Description : string
}

interface ForumWithPosts{
    creator : string
    title : string
    description : string
    created : Date
    posts : PostCard[]
}

export { ForumToBack, ForumWithPosts }