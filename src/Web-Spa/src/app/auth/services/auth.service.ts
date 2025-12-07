import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { GET_USER_BY_ID, GET_USERS } from '../gql/queries/users-queries';
import { query } from 'express';
import { CREATE_USER } from '../gql/mutations/users-mutaions';
import { LoginVm, UserVm } from '../interfaces/user-vm';
import { HttpClient } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private apollo: Apollo, private http: HttpClient) { }

  test():Observable<any[]>
  {
    return this.http.get<any[]>('https://cataas.com/api/cats?limit=10&skip=0');
  }

  getUsers(): Observable<UserVm[] | []> {
    return this.apollo
      .watchQuery<{ users: UserVm[] }>({ query: GET_USERS })
      .valueChanges
      .pipe(
        map(result => {
          console.log(result.data.users);
          return result.data.users;
        })
      );
  }

  getUserById(id: string): Observable<UserVm | null> {
    return this.apollo.watchQuery<{ user: UserVm }>({
      query: GET_USER_BY_ID,
      variables: { id }
    }).valueChanges
      .pipe(map(result => {
        console.log(result.data.user)
        return result.data.user
      }))
  }

  register(userVm: UserVm): Observable<UserVm> {
    console.log(userVm);
    return this.apollo.mutate<{ register: UserVm }>({
      mutation: CREATE_USER, variables: { userVm }
    }).pipe(map(result =>
      result.data?.register as UserVm
    ));
  }
  
  login(LoginVm: LoginVm): Observable<UserVm | null>
  {
    return null  as any;
  }

}
