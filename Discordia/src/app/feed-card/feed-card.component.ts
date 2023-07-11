import { Component, Input, ViewChild, ViewRef } from '@angular/core';
import { Post } from '../services/Model';
import { PostCard } from '../services/Post';

@Component({
  selector: 'app-feed-card',
  templateUrl: './feed-card.component.html',
  styleUrls: ['./feed-card.component.css']
})
export class FeedCardComponent {

  @Input() obj : PostCard | any;

  post : PostCard = {
    creatorIdJwt: '',
    forumTitle: '',
    title: '',
    content: '',
    attachment: false,
    created : new Date
  };

  protected liked = false;
  protected unliked = false;

  ngOnInit() {
    this.post = this.obj
    this.post.created = new Date(this.obj.created)
  }

  protected viewConfig = false;
  protected mostConfig(){
    this.viewConfig =  !this.viewConfig;
  }

  like(){
    this.unliked = false
    this.liked = !this.liked
  }
  unlike(){
    this.unliked = !this.unliked
    this.liked = false

  }

}
