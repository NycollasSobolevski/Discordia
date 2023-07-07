import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ForumService } from '../services/forum.service';
import { ForumWithPosts } from '../services/Forum';
import { Post } from '../services/Model';

@Component({
  selector: 'app-forum-page',
  templateUrl: './forum-page.component.html',
  styleUrls: ['./forum-page.component.css']
})
export class ForumPageComponent {
  forumname = ''
  subscription : any;

  forum : ForumWithPosts ={
    created: new Date,
    description: "",
    title: "",
    posts: [],
    creator: ''
  };

  constructor ( private route : ActivatedRoute, private router : Router, private service : ForumService) {  }

  ngOnInit () : void {
    this.subscription = this.route.params.subscribe((params) => {
      let forumname = params['forum']
      this.service.GetForumPage(forumname).subscribe({
        next: (res) => {
          this.forum = res
        },
        error: (err) => {
          this.router.navigate(['/404'])
        }
      },

      )
      
    });
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  

}
