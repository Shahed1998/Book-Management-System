import { ApiService } from 'src/app/api.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { ModalComponent } from '../../modal/modal.component';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  @ViewChild(ModalComponent) modal!: ModalComponent;

  genre: Array<String> = ["Fantasy", "Science", "Horror"];
  authors: any
  authorId: number = 0 
  faPlus= faPlusCircle
  title!: string
  genreId: number = 0
  description!: string
  price!: number
  publishers: any
  publisherId: number = 0
  selectedAuthor!: Array<any>

  // ----------------------- Modal
  entity!: string
  route!: string

  constructor(private apiservice: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.getPublishers()
    this.getAuthors()
  }

  getPublishers()
  {
    this.apiservice.getPublishersNoPage().subscribe(res => {
      var resp:any = res
      this.publishers = resp.data
    })
  }

  getAuthors()
  {
    this.apiservice.getAllAuthors().subscribe(res => {
      var resp: any = res
      this.authors = resp.data
    })
  }

  addBook()
  {
    const data = {
      "Title": this.title,
      "Type": Number(this.genreId),
      "Description": this.description,
      "Price": this.price,
      "PublisherId": Number(this.publisherId)
    }

    
    
    this.apiservice.addBook(data).subscribe(res => {

      var book:any = res
      var bookId = book.data.id
      this.selectedAuthor.forEach((el:any)=>{
        this.apiservice.addBookAuthor({"AuthorId": el.id, "BookId": bookId}).subscribe(res=>{
          this.entity = "Book saved"
          this.route = '/books'
          this.modal.modalTrigger()
        }, err =>{})
      })
    },
    err => {
      this.entity = "Unable to save book"
      this.route = '/books'
      this.modal.modalTrigger()
    })
  }

  selectedAuthors(event:any)
  {
    this.selectedAuthor = event
  }

}
