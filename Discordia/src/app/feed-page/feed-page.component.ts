import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ForumService } from '../services/forum.service';
import { PostService } from '../services/post.service';
import { GetUserPosts, PostCard } from '../services/Post';

@Component({
  selector: 'app-feed-page',
  templateUrl: './feed-page.component.html',
  styleUrls: ['./feed-page.component.css']
})
export class FeedPageComponent {
  session = sessionStorage.getItem("jwt") ?? "";


  constructor ( private router : Router, private service : PostService) {  }

  ngOnInit( ) {
    if (this.session == "") {
      this.router.navigate(['login-page'])
    }
    else{
      this.getforums()
    }
  }



  protected data : GetUserPosts = {
    jwt: sessionStorage.getItem('jwt') ?? '',
    page: 0,
    quantity: 0
  }

  postList : PostCard[] = [] 

  getforums(){
    this.service.GetUserPosts(this.data).subscribe( 
      item => {
        let list: PostCard[] = []
        item.forEach(posts => {
          list.push(posts)
          this.postList = list;
          console.log(this.postList);
        })
      }
    )
  }

}
