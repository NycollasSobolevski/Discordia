import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { LoginComponent } from './login/login.component';
import { NewAccountComponent } from './new-account/new-account.component';
import { HomePageComponent } from './home-page/home-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { MenuComponent } from './menu/menu.component';
import { FeedCardComponent } from './feed-card/feed-card.component';
import { NewPostComponent } from './new-post/new-post.component';
import { FormsModule } from '@angular/forms';
import { MenuComponentComponent } from './menu-component/menu-component.component';
import { NewForumComponent } from './new-forum/new-forum.component';
import { ForumPageComponent } from './forum-page/forum-page.component';
import { AllForumsPageComponent } from './all-forums-page/all-forums-page.component';
import { ForumCardComponent } from './forum-card/forum-card.component';
import { FoumInitialPageComponent } from './foum-initial-page/foum-initial-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginPageComponent,
    LoginComponent,
    NewAccountComponent,
    HomePageComponent,
    FeedPageComponent,
    MenuComponent,
    FeedCardComponent,
    NewPostComponent,
    MenuComponentComponent,
    NewForumComponent,
    ForumPageComponent,
    AllForumsPageComponent,
    ForumCardComponent,
    FoumInitialPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
