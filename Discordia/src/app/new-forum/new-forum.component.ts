import { Component,NgModule } from '@angular/core';
import { Forum } from '../services/Forum'
import { Jwt } from '../services/person';

@Component({
  selector: 'app-new-Forum',
  templateUrl: './new-forum.component.html',
  styleUrls: ['./new-forum.component.css']
})
export class NewForumComponent {
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
