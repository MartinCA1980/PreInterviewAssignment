import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import {AuthService} from '../services/auth.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
    loading = false;
    submitted = false;
    error: string;
    
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService) 
    { 
      if (this.authService.currentUserValue) {
        this.router.navigate(['/']);
    }
    }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    
    if (this.registerForm.invalid) {
        return;
    }

    this.loading = true;
    
    this.authService.register(this.registerForm.value.email, this.registerForm.value.password, this.registerForm.value.name)        
        .subscribe(
            data => {
                this.router.navigate(['/login'], { queryParams: { registered: true }});
            },
            err => {              
              this.loading = false;
              this.error = err;                
              
            });
}

}
