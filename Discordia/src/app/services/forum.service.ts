import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Forum } from "./Forum";


@Injectable({
    providedIn: 'root'
})
export class ForumService {
    constructor(private http : HttpClient) {  }

    CreateForum(forum : Forum){
        return this.http.post('http://localhost:5283/forum/createForum' , forum)
    }
}