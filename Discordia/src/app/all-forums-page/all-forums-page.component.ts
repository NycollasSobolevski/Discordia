import { Component } from '@angular/core';
import { Forum } from '../services/Model';
import { ForumService } from '../services/forum.service';

@Component({
  selector: 'app-all-forums-page',
  templateUrl: './all-forums-page.component.html',
  styleUrls: ['./all-forums-page.component.css']
})
export class AllForumsPageComponent {
  protected allForums : Forum[] = []
  protected newListForums : Forum[] = []
  search = ''

  searchChanged(string : string){
  //   console.log(this.allForums);
  //   this.search = string;
  //   this.newListForums = this.allForums.filter(x => x.Title );
  //   console.log(this.newListForums);
    
  }

  constructor( private service : ForumService ){  }

  ngOnInit() : void  {
    this.getForums()
  }

  getForums(){
    this.service.GetAllForums()
      .subscribe( (item : any) => {
        let list : Forum[] = []
        item.forEach((element : any )=> {
          list.push(element);
        });
        this.allForums = list;
        console.log(this.allForums);
        
    })
  }
}
