import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ForumToBack } from "./Forum";
import { Forum } from "./Model";
import { Jwt } from "./person";


@Injectable({
    providedIn: 'root'
})
export class ForumService {
    constructor(private http : HttpClient) {  }

    CreateForum(forum : ForumToBack){
        return this.http.post('http://localhost:5283/forum/createForum' , forum)
    };
    GetUserForums(user : Jwt){
        return this.http.post<Forum[]>('http://localhost:5283/forum/getUserForumsFollowed', user)
    }
}