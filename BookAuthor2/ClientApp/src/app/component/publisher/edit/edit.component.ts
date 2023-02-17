import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  publisher: any
  publisherId!: number
  spinner: boolean = false

  constructor(private apiService: ApiService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(param => {
      ! Number(param.get('id')) ? this.router.navigate(['/']) : this.publisherId = Number(param.get('id'))
      this.getPublisher()    
    })
  }

  getPublisher()
  {
    this.apiService.getPublisher(this.publisherId).subscribe(res => {
      this.publisher = res
      this.publisher = this.publisher.data.name
    })
  }

  update()
  {
    this.spinner = true;
    this.apiService.updatePublisher({Id: this.publisherId, Name: this.publisher}).subscribe(res => {
      this.spinner = false
      alert("Publisher updated successfully")
      this.router.navigate(['/publishers'], {queryParams: {page: 1}})
    }, err => {
      this.spinner = false
      alert("Unable to update publisher")
    })
  }
}
