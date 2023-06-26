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
    NewPostComponent
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
