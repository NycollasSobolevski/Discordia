import { HttpClient } from "@angular/common/http";
import { Post } from "./Model";
import { Injectable } from "@angular/core";
import { GetUserPosts, PostCard } from "./Post";
import { func } from "./Permissions";
import { getPermissions } from "./Forum";


@Injectable({
    providedIn: "root"
})
export class PostService {
    constructor ( private http : HttpClient ) {  }

    CreatePost( post : Post){
        return this.http.post('http://localhost:5283/post/createPost', post)
    };

    GetUserPosts ( data : GetUserPosts ) {
        return this.http.post<PostCard[]>( 'http://localhost:5283/post/GetUserPosts', data)
    };

    getPermissions ( data : getPermissions) {
        return this.http.post<func[]>( 'http://localhost:5283/post/GetPermissions', data)
    }
}