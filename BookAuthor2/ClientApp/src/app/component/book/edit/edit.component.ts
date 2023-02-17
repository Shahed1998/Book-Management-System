import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { faInfoCircle, faPenNib, faTrash, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { environment } from 'src/environments/environment';
import { ModalComponent } from '../../modal/modal.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  @ViewChild(ModalComponent) modal!: ModalComponent;
  
  genre: any = environment.bookGenres;
  book: any
  bookId!: Number 
  publishers: any
  faInfo = faInfoCircle;
  faPenNib = faPenNib;
  faCross = faTrash;
  faPlus = faPlusCircle;
  bookDetails: any
  spinner: boolean = false

  // ----------------------- Form input
  title!: string
  type!: number
  description!: string
  price!: number
  publishedDate!: string
  publisherId!: number
  authors: any
  totalAuthors!: number
  allAuthors!: any
  selectedAuthorIds: Array<string> = []
  selectedAuthors: Array<object> = []

  // ----------------------- Modal
  entity!: string
  route!: string

  constructor(private apiservice: ApiService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param)=>{
      !Number(param.get('id')) ? this.router.navigate(['/books']) : this.bookId = Number(param.get('id'));
    })
    this.getBookDetails(this.bookId)
    this.getPublishers()
    this.getAuthors()
  }

  getBookDetails(id: Number)
  {
    this.apiservice.getBookById(id).subscribe(res => {
      this.bookDetails = res
      this.title = this.bookDetails.data.title
      this.type = this.bookDetails.data.type
      this.description = this.bookDetails.data.description
      this.price = this.bookDetails.data.price
      this.publishedDate = this.bookDetails.data.publishedDate.split('T')[0]
      this.publisherId = this.bookDetails.data.publisher.id
      this.authors = this.bookDetails.data.authors
      this.totalAuthors = this.authors.length   
      this.selectedAuthors = this.authors

      var selectedAuthorIdsTemp = []
      var emptied: Array<string> = []

      for(let i=0; i<this.authors.length; i++)
      {
        selectedAuthorIdsTemp.push(this.authors[i].id)
      }


      var uniqueIds = new Set(selectedAuthorIdsTemp)

      uniqueIds.forEach(ids => emptied.push(ids))

      this.selectedAuthorIds = emptied;
      
    })
  }

  getAuthors()
  {
    this.apiservice.getAllAuthors().subscribe(res => {
      this.allAuthors = res;
      this.allAuthors = this.allAuthors.data;
    })
  }

  getPublishers()
  {
    this.apiservice.getPublishersNoPage().subscribe(res => {
      var resp:any = res
      this.publishers = resp.data
    })
  }

  editBook()
  {    
    this.spinner = true

    const data = {
      "Id": this.bookId,
      "Title": this.title,
      "Type": Number(this.type),
      "Description": this.description,
      "Price": this.price,
      "PublisherId": Number(this.publisherId)
    }

    this.apiservice.editBook(data).subscribe(res => {
      this.editAuthorSelected()

      this.spinner = false
      this.entity = "Book updated successfully"
      this.route = '/books'
      this.modal.modalTrigger()
    }, err => {
      this.entity = "Book update failed"
      this.route = '/books'
      this.modal.modalTrigger()
      this.spinner = false
    })
  }


  editAuthorSelected(){

    var arr = this.authors.filter((el:any) => !this.selectedAuthors.some((el2:any) => el.id === el2.id)) // array to be removed
    var arr2 = this.selectedAuthors

    if(arr.length > 0)
    {
      arr.forEach((el:any)=>{
          this.apiservice.deleteBookAuthor(el.id, this.bookId).subscribe(res=>{ }, err => {
            // this.entity = "Book update failed"
            // this.route = '/books'
            // this.modal.modalTrigger()
            // this.spinner = false
          })
      })
    }

    arr2.forEach((el:any)=>{
      this.apiservice.addBookAuthor({"AuthorId": el.id, "BookId": this.bookId}).subscribe(res=>{
      }, err =>{})
    })      
  }



  addAuthor() { this.router.navigate(['/author/add'], {queryParams: {bookId: this.bookId}}) }

  selectedAuthorFn(event: Array<object>) { this.selectedAuthors = event }

  authorMouseLeave(event: any) { event.target.style.fontSize = "100%"; }

  authorMouseEnter(event: any) { event.target.style.fontSize = "120%"; }
}


