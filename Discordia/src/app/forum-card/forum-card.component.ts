import { Component, Input } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { ForumToBack } from '../services/Forum';
import { Router } from '@angular/router';
import { Forum } from '../services/Model';

@Component({
  selector: 'app-forum-card',
  templateUrl: './forum-card.component.html',
  styleUrls: ['./forum-card.component.css']
})
export class ForumCardComponent {
  @Input() obj : any;
  @Input() followedList : Forum[] = [];

  protected followed = false;

  constructor ( private service : ForumService, private router : Router ) {  }

  private sla : ForumToBack = {
    CreatorIdJwt: '',
    Title: '',
    Description: ''
  }

  ngOnInit(){
    this.checkIfFollow(this.followedList);
    this.sla.Title = this.obj.title
    console.log("followedList" + this.followedList);
    
  }
  
  checkIfFollow(forumList: Forum[])
  {
    forumList.forEach(element => {
      if (element.Title === this.obj.title) {
        this.followed = true;
      }
      console.log(element);
    });
  }

  follow(){
    this.followed = !this.followed
  }
  unfollow(){
    this.followed = !this.followed
  }

  func(){
    this.router.navigate(['forum/'+ this.obj.title])
  }

}
