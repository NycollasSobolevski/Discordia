import { Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Output() followClicked = new EventEmitter<void>()

  protected followed = false;

  constructor ( private service : ForumService, private router : Router ) {  }

  private sla : ForumToBack = {
    CreatorIdJwt: '',
    Title: '',
    Description: ''
  }

  ngOnInit() {
    this.sla.Title = this.obj.title
    this.checkIfFollow(this.followedList);
  }
  
  ngOnChanges() {
    this.checkIfFollow(this.followedList)
  }

  checkIfFollow(forumList: Forum[])
  {
    forumList.forEach(( element : ForumToBack | any ) => {
      if(this.sla.Title === element.title)
        this.followed = true
        
    });
  }

  follow(){
    let forum : ForumToBack = {
      CreatorIdJwt: sessionStorage.getItem('jwt') ?? "",
      Title: this.sla.Title,
      Description: ''
    }
    this.service.FollowForum( forum ).subscribe({
      next : (res) => {
        console.log(res);
        
      }
    })
    this.followClicked.emit();
  }

  unfollow(){
    let forum : ForumToBack = {
      CreatorIdJwt: sessionStorage.getItem('jwt') ?? "",
      Title: this.sla.Title,
      Description: ''
    }
    this.service.UnfollowForum( forum ).subscribe({
      next : (res) => {
        console.log(res);
        
      }
    })
    this.followClicked.emit();
  }

  func(){
    this.router.navigate(['forum/'+ this.obj.title])
  }

}
