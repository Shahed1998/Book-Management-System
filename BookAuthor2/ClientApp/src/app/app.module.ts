import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthorComponent } from './component/author/author.component';
import { BookComponent } from './component/book/book.component';
import { HomeComponent } from './component/home/home.component';
import { NavbarComponent } from './component/navbar/navbar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthorDetailComponent } from './component/author/detail/detail.component';
import { EditComponent as AuthorEditComponent } from './component/author/edit/edit.component';
import { DeleteComponent as AuthorDeleteComponent } from './component/author/delete/delete.component';
import { PageNotFoundComponent } from './component/page-not-found/page-not-found.component';
import { AddComponent as AuthorAddComponent } from './component/author/add/add.component';
import { AddComponent as BookAddComponent } from './component/book/add/add.component';
import { EditComponent as BookEditComponent } from './component/book/edit/edit.component';
import { DeleteComponent as BookDeleteComponent } from './component/book/delete/delete.component';
import { DetailsComponent as BookDetailsComponent } from './component/book/details/details.component';
import { PaginationButtonComponent } from './component/pagination-button/pagination-button.component';
import { SpinnerComponent } from './component/spinner/spinner.component';
import { SidebarComponent } from './component/sidebar/sidebar.component';
import { PublisherComponent } from './component/publisher/publisher.component';
import { AddComponent as PublisherAddComponent } from './component/publisher/add/add.component';
import { InfoComponent as PublisherDetailComponent } from './component/publisher/info/info.component';
import { EditComponent as PublisherEditComponent } from './component/publisher/edit/edit.component';
import { DeleteComponent as PublisherDeleteComponent } from './component/publisher/delete/delete.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { ModalComponent } from './component/modal/modal.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthorComponent,
    BookComponent,
    HomeComponent,
    NavbarComponent,
    AuthorDetailComponent,
    AuthorEditComponent,
    AuthorDeleteComponent,
    PageNotFoundComponent,
    AuthorAddComponent,
    BookAddComponent,
    BookEditComponent,
    BookDeleteComponent,
    BookDetailsComponent,
    PaginationButtonComponent,
    SpinnerComponent,
    SidebarComponent,
    PublisherComponent,
    PublisherAddComponent,
    PublisherDetailComponent,
    PublisherEditComponent,
    PublisherDeleteComponent,
    ModalComponent,
  ],

  imports: [
    NgSelectModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'author/add', component: AuthorAddComponent},
      {path: 'authors', component: AuthorComponent },
      {path: 'author/details/:id', component: AuthorDetailComponent},
      {path: 'author/edit/:id', component: AuthorEditComponent},
      {path: 'author/delete/:id', component: AuthorDeleteComponent},

      {path: 'books', component: BookComponent},
      {path: 'book/add', component: BookAddComponent},
      {path: 'book/details/:id', component: BookDetailsComponent},
      {path: 'book/delete/:id', component: BookDeleteComponent},
      {path: 'book/edit/:id', component: BookEditComponent},

      {path: 'publishers', component: PublisherComponent},
      {path: 'publisher/add', component: PublisherAddComponent},
      {path: 'publisher/details/:id', component: PublisherDetailComponent},
      {path: 'publisher/edit/:id', component: PublisherEditComponent},
      {path: 'publisher/delete/:id', component: PublisherDeleteComponent},

      {path: '**', pathMatch: 'full', component: PageNotFoundComponent}
      
    ]),
    FontAwesomeModule,
    FormsModule,  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
