import { Component } from '@angular/core';
import { Forum } from '../services/Forum'
import { Jwt } from '../services/person';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent {
  protected titleCount = 0;
  protected textCount = 0;
  protected title = '';
  protected text = '';
  protected viewContainer = false;

  

  protected forum : Forum = {
    CreatorId : sessionStorage.getItem('jwt') ?? "",
    Title : this.title,
    Description : this.text
  }

  protected updateText(newValue : string){
    this.textCount = newValue.length ;
  }
  protected updateTitle(newValue : string) {
  this.titleCount = newValue.length ;
  }
  protected view(){
    this.viewContainer = !this.viewContainer;
  } 



  createForum(){
    
  }
}
