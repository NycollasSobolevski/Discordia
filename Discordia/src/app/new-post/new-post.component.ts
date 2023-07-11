import { Component, Input, NgModule } from '@angular/core';

import { ForumToBack, getPermissions } from '../services/Forum'
import { Jwt } from '../services/person';
import { Forum, Post } from '../services/Model';
import { ForumService } from '../services/forum.service';
import { PostService } from '../services/post.service';
import { func } from '../services/Permissions';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent {
  @Input() forumName : string = '' 

  newPost = false;

  constructor (
    private forumService : ForumService,
    private postService : PostService
    ) {  }  
  
    pageData : getPermissions = {
      jwt: sessionStorage.getItem('jwt') ?? '',
      forumName: this.forumName
    }

  private jwt : Jwt = {
    value : sessionStorage.getItem('jwt') ?? ""
  }  
  protected titleCount = 0;
  protected textCount = 0;
  protected viewContainer = false;

  protected post : Post = {
    creatorIdJwt: this.jwt.value,
    forumTitle: '',
    title: '',
    content: '',
    attachment: false,
    created: new Date
  }

  protected avaliableForums : any[] = []


  ngOnInit(){
    if(this.jwt.value == "")
      return
    }
    
  ngOnChanges(){
    this.post.forumTitle = this.forumName
    // this.verifyIfPost()
  }

  //// getAvaliableForums(){
  ////   return this.forumService
  ////     .GetUserForums(this.jwt)
  ////     .subscribe( item => {
  ////       let list: Forum[] = []
  ////       item.forEach(forums => {
  ////         list.push(forums)
  ////       })
  ////       this.avaliableForums = list;
  ////     })
  //// }



  verifyIfPost(){
    this.postService.getPermissions(this.pageData).subscribe({
      next : (item) => {
        item.forEach((element : func) => {
          if (element.name == 'Post')
            this.newPost = true
        });
      }
    })
  }

  getSelectValue( event : any ) {
    this.post.forumTitle = event.target.value;
  }

  protected updateText(newValue : string) {
    this.textCount = newValue.length ;
  }
  protected updateTitle(newValue : string) {
  this.titleCount = newValue.length ;
  }
  protected view(){
    this.viewContainer = !this.viewContainer;
  } 


  checkContent(){
    
    return this.textCount > 0 && this.post.forumTitle != ""
  }

  createPost(){
    if(!this.checkContent)
    {
      //! : Alert colocar alerta de conteudo faltante
      location.reload()

      return
    }
    
    this.postService.CreatePost(this.post)
      .subscribe({
        next: (returned) => {
          location.reload()
        },
        error: (err) => {
          console.log(err);
        },
        complete: () => {
          location.reload()
        }
      })
  }
}