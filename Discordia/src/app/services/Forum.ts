import { Post } from "./Model"
import { PostCard } from "./Post"
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

interface getPermissions{
    jwt : string
    forumName : string
}

export { ForumToBack, ForumWithPosts, getPermissions }