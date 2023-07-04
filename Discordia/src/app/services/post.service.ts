import { HttpClient } from "@angular/common/http";
import { Post } from "./Model";
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: "root"
})
export class PostService {
    constructor ( private http : HttpClient ) {  }

    CreatePost( post : Post){
        return this.http.post('http://localhost:5283/post/createPost', post)
    }
}