const heart= document.querySelectorAll(".favbutton");

const heartValue=document.querySelectorAll(".heartvalue");

for (let i = 0; i < heart.length; i++) {
    heart[i].addEventListener("click",function(){

        console.log("clicked");
        if(heart[i].classList.contains("fa-heart"))
        {
            heart[i].classList.remove("fa-heart");
            heart[i].classList.add("fa-heart-o");
        heartValue[i].textContent="Added to your Favorites";
    
        }
        else if(heart[i].classList.contains("fa-heart-o"))
        {
            heart[i].classList.remove("fa-heart-o");
            heart[i].classList.add("fa-heart");
        heartValue[i].textContent="Removed from your Favorites";
    
        }

        })


        heart[i].addEventListener("mouseover",function(){

            if(heart[i].classList.contains("fa-heart"))
            {
                heart[i].classList.remove("fa-heart");
                heart[i].classList.add("fa-heart-o");
            
        
            }
            else if(heart[i].classList.contains("fa-heart-o"))
            {
                heart[i].classList.remove("fa-heart-o");
                heart[i].classList.add("fa-heart");

            }
    
            })
    
            heart[i].addEventListener("mouseout",function(){
    
                if(heart[i].classList.contains("fa-heart"))
                {
                    heart[i].classList.remove("fa-heart");
                    heart[i].classList.add("fa-heart-o");
                
            
                }
                else if(heart[i].classList.contains("fa-heart-o"))
                {
                    heart[i].classList.remove("fa-heart-o");
                    heart[i].classList.add("fa-heart");
                }
        
                })
    
}

    