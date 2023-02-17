import { Router } from '@angular/router';
import { ApiService } from './../../../api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  publisherName!: string
  spinner: boolean = false

  constructor(private apiservices: ApiService, private router: Router) { }

  ngOnInit(): void { }

  save() {
    this.spinner = true
    this.apiservices.addPublisher({"Name": this.publisherName}).subscribe(res => {
      alert("Successfully added publisher")
      this.spinner = false
      this.router.navigate(['/publishers'], {queryParams: {page: 1}})
    }, err => {
      alert("Unable to add publisher")
      this.spinner = false
    })
  }
}
