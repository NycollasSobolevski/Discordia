import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ForumToBack, ForumWithPosts } from "./Forum";
import { Forum } from "./Model";
import { Jwt } from "./person";


@Injectable({
    providedIn: 'root'
})
export class ForumService {
    constructor ( private http : HttpClient ) {  }

    CreateForum(forum : ForumToBack){
        return this.http.post( 'http://localhost:5283/forum/createForum' , forum )
    };
    GetUserForums(jwt : Jwt){
        return this.http.post<Forum[]>( 'http://localhost:5283/forum/getUserForumsFollowed', jwt )
    };
    GetAllForums(){
        return this.http.get( 'http://localhost:5283/forum/GetAllForuns' )
    };
    PostForumPage( forum : ForumToBack ){
        return this.http.post( 'http://localhost:5283/forum/GetForumPage', forum )
    };
    GetForumPage(name : string){
        return this.http.get<ForumWithPosts>( 'http://localhost:5283/forum/GetForumPage/' + name ) 
    };
    FollowForum( forum : ForumToBack ){
        return this.http.post( 'http://localhost:5283/forum/FollowForum', forum )
    };
    UnfollowForum( forum : ForumToBack ){
        return this.http.post( 'http://localhost:5283/forum/UnfollowForum', forum )
    };

}